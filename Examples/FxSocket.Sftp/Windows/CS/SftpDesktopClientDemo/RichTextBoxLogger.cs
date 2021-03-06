using System;
using System.Drawing;
using System.Windows.Forms;
using FxSocket;

namespace FxSocketSamples
{
	/// <summary>
	/// Implementation of FxSocket.ILogger which logs to specified RichTextBox.
	/// </summary>
	public class RichTextBoxLogger : FxSocket.BaseVerboseLogger
	{
		// colors
		internal static readonly Color COLORRESPONSE = Color.Black;     // SFTP response color
		internal static readonly Color COLORCOMMAND = Color.DarkGreen;  // SFTP command color
		internal static readonly Color COLORERROR = Color.Red;          // color of error messages
		internal static readonly Color COLORINFO = Color.Blue;          // info color
		internal static readonly Color COLORSSH = Color.BlueViolet;     // color of SSH comunication
		internal static readonly Color COLORTLS = Color.BlueViolet;     // color of TLS comunication

		private RichTextBox _textbox;
		private int _maxCharsCount;
	
		public RichTextBoxLogger(RichTextBox textbox, int maxCharsCount, LogLevel level)
		{
			_textbox = textbox;
			_maxCharsCount = maxCharsCount;
			Level = level;
		}

		public override void Write(LogLevel level, Type objectType, int objectId, string area, string message)
		{
			if (level < Level)
				return;

			Color color = COLORINFO;

			if (level >= LogLevel.Error)
			{
				color = COLORERROR;
			}
			else
			{
				switch (area.ToUpper())
				{
					case "COMMAND": color = COLORCOMMAND; break;
					case "RESPONSE": color = COLORRESPONSE; break;
					case "SSH": color = COLORSSH; break;
					case "TLS": color = COLORTLS; break;
				}
			}

			message = string.Format("{0:HH:mm:ss.fff} {1} {2}: {3}\r\n", 
				DateTime.Now, level.ToString(), area, message);

			try
			{
				if (!_textbox.IsDisposed)
					_textbox.Invoke(new WriteLogHandler(WriteLog), new object[] { message, color });
			}
			catch (ObjectDisposedException)
			{
			}
		}

		private delegate void WriteLogHandler(string message, Color color);

		private void WriteLog(string message, Color color)
		{				
			EnsureTextSpace(message.Length);

			_textbox.Focus();
			_textbox.SelectionColor = color;
			_textbox.AppendText(message);
		}

		private void EnsureTextSpace(int length)
		{
			if(_textbox.TextLength + length < _maxCharsCount)
				return;

			int spaceLeft = _maxCharsCount - length;

			if(spaceLeft <= 0)
			{
				_textbox.Clear();
				return;
			}

			string plainText = _textbox.Text;

			// find the end of line
			int start = plainText.IndexOf('\n', plainText.Length - spaceLeft);
			if(start >= 0 && start + 1 < plainText.Length)
			{
				_textbox.SelectionStart = 0;
				_textbox.SelectionLength = start + 1;

				// setting the SelectedText property is available only when ReadOnly = false
				bool ro = _textbox.ReadOnly;
				_textbox.ReadOnly = false;
				_textbox.SelectedText = "";
				_textbox.ReadOnly = ro;

				_textbox.SelectionStart = _textbox.TextLength;
				_textbox.SelectionLength = 0;
			}
			else
			{
				_textbox.Clear();
			}
		}
	}
}

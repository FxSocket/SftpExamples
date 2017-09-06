Imports System.Collections
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports FxSocket
Imports FxSocket.FileSystem
Imports FxSocket.Net
Imports Microsoft.Win32

Namespace FxSocketSamples
	Friend NotInheritable Class Common

		Private Sub New()
		End Sub

		''' <summary>
		''' format datetime to readable form in the panels
		''' </summary>
		''' <param name="dt">datetime</param>
		''' <returns>formatted string</returns>
		Public Shared Function FormatTime(ByVal dt As Date) As String
			Return dt.ToString("yyyy-MM-dd HH:mm")
		End Function

		Public Shared Function FormatTime(ByVal dt As Nullable(Of Date)) As String
			If dt.HasValue Then
				Return dt.Value.ToString("yyyy-MM-dd HH:mm")
			Else
				Return Nothing
			End If
		End Function

		Public Shared Function BytesToString(ByVal byteCount As Long) As String
			Dim suf() As String = { "B", "KB", "MB", "GB", "TB", "PB", "EB" } 'Longs run out around EB
			If byteCount = 0 Then
				Return "0" & suf(0)
			End If
			Dim bytes As Long = Math.Abs(byteCount)
			Dim place As Integer = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)))
			Dim num As Double = Math.Round(bytes / Math.Pow(1024, place), 1)
			Return (Math.Sign(byteCount) * num).ToString() & suf(place)
		End Function

		#Region "Save and Get Registry Values"

		Public Shared Sub SetKey(ByVal keyName As String, ByVal value As Object)
			Try
				Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\FxSocket\" & System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)
				key.SetValue(keyName, value)
			Catch
				Return
			End Try
		End Sub

		Public Shared Function GetKey(ByVal keyName As String, ByVal defaultValue As Object) As Object
			Try
				Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\FxSocket\" & System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)
				Return key.GetValue(keyName, defaultValue)
			Catch
				Return defaultValue
			End Try
		End Function

		Public Shared Function GetKey(ByVal keyName As String) As Object
			Return GetKey(keyName, CObj(Nothing))
		End Function

		Public Shared Function GetKey(ByVal keyName As String, ByVal defaultValue As Integer) As Integer
			Try
				Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\FxSocket\" & System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)
				Return Integer.Parse(key.GetValue(keyName, defaultValue).ToString())
			Catch
				Return defaultValue
			End Try
		End Function

		Public Shared Function GetKey(ByVal keyName As String, ByVal defaultValue As Long) As Long
			Try
				Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\FxSocket\" & System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)
				Return Long.Parse(key.GetValue(keyName, defaultValue).ToString())
			Catch
				Return defaultValue
			End Try
		End Function

		Public Shared Function GetKey(ByVal keyName As String, ByVal defaultValue As Boolean) As Boolean
			Try
				Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\FxSocket\" & System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)
				Return key.GetValue(keyName, defaultValue).ToString() = "True"
			Catch
				Return defaultValue
			End Try
		End Function

		#End Region
	End Class

	Public Enum ComparisonMethod
		Name
		Ext
		Size
		[Date]
		Permissions
	End Enum

	Public Class ListViewColumnSorter
		Implements IComparer
		Private _ascending As Boolean
		Private _comparisonMethod As ComparisonMethod

		Public Sub New()
			_ascending = True
		End Sub

		Public Property Ascending() As Boolean
			Get
				Return _ascending
			End Get
			Set(ByVal value As Boolean)
				_ascending = value
			End Set
		End Property

		Public Property ComparisonMethod() As ComparisonMethod
			Get
				Return _comparisonMethod
			End Get
			Set(ByVal value As ComparisonMethod)
				_comparisonMethod = value
			End Set
		End Property

		Private Function CompareTime(ByVal x As Date, ByVal y As Date) As Integer
			If x = y Then
				Return 0
			End If
			If _ascending Then
				If x > y Then
					Return 1
				Else
					Return -1
				End If
			End If

			If x < y Then
				Return 1
			Else
				Return -1
			End If
		End Function

		Private Function IComparer_Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
			Dim listViewX As ListViewItem = CType(x, ListViewItem)
			Dim listViewY As ListViewItem = CType(y, ListViewItem)

			Dim itemX As ListItemInfo = CType(listViewX.Tag, ListItemInfo)
			Dim itemY As ListItemInfo = CType(listViewY.Tag, ListItemInfo)

			If itemX.IsDirectory AndAlso (Not itemY.IsDirectory) Then
				Return -1
			End If

			If (Not itemX.IsDirectory) AndAlso itemY.IsDirectory Then
				Return 1
			End If

			If itemX.IsUpper AndAlso (Not itemY.IsUpper) Then
				Return -1
			End If

			If (Not itemX.IsUpper) AndAlso itemY.IsUpper Then
				Return 1
			End If

			Select Case _comparisonMethod
				Case ComparisonMethod.Name
					Dim xname As String = Path.GetFileName(itemX.FullPath)
					Dim yname As String = Path.GetFileName(itemY.FullPath)
					If _ascending Then
						Return String.CompareOrdinal(xname, yname)
					Else
						Return String.CompareOrdinal(yname, xname)
					End If

				Case ComparisonMethod.Ext
					Dim xext As String = Path.GetExtension(itemX.FullPath)
					Dim yext As String = Path.GetExtension(itemY.FullPath)
					If _ascending Then
						Return String.CompareOrdinal(xext, yext)
					Else
						Return String.CompareOrdinal(yext, xext)
					End If

				Case ComparisonMethod.Size
					If _ascending Then
						Return CInt(itemX.Size - itemY.Size)
					Else
						Return CInt(itemY.Size - itemX.Size)
					End If

				Case ComparisonMethod.Date
					If _ascending Then
						Return CompareTime(itemX.Time, itemY.Time)
					Else
						Return CompareTime(itemY.Time, itemX.Time)
					End If
			End Select

			Return 0
		End Function
	End Class
End Namespace

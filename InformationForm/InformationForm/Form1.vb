Imports System.IO
Imports System.DateTime
Imports System.Xml
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class Form1
    Public Property today As String = Date.Now.ToString("yyyy-MM-dd HH-mm-ss")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txtFile As System.IO.StreamWriter
        Dim info As Info = New Info()
        txtFile = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\G\source\repos\InformationForm\InformationForm\ExportedFiles\" & "TextFile - " & today & ".txt", True)

        info.getInfo(TextBox1.Text, TextBox2.Text, TextBox3.Text)

        Dim output As String = "name : " & info.name & vbCrLf &
                               "age : " & info.age & vbCrLf &
                               "address : " & info.address & vbCrLf


        Label4.Text = "Check the file at C:\Users\G\source\repos\InformationForm\InformationForm\ExportedFiles\"

        txtFile.WriteLine(output)
        txtFile.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim info As Info = New Info()
        info.getInfo(TextBox1.Text, TextBox2.Text, TextBox3.Text)

        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        Using writer As XmlWriter = XmlWriter.Create("C:\Users\G\source\repos\InformationForm\InformationForm\ExportedFiles\" & "XmlFile - " & today & ".xml", settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("Person")

            writer.WriteStartElement("Info")
            writer.WriteElementString("name", info.name)
            writer.WriteElementString("age", info.age)
            writer.WriteElementString("address", info.address)
            writer.WriteEndElement()

            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using

        Label4.Text = "Check the file at C:\Users\G\source\repos\InformationForm\InformationForm\ExportedFiles\"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim info As Info = New Info()
        info.getInfo(TextBox1.Text, TextBox2.Text, TextBox3.Text)

        Dim jsonString As String = JsonConvert.SerializeObject(info)

        Dim file As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\G\source\repos\InformationForm\InformationForm\ExportedFiles\" & "JsonFile - " & today & ".json", True)
        file.WriteLine(jsonString)
        file.Close()

        Label4.Text = "Check the file at C:\Users\G\source\repos\InformationForm\InformationForm\ExportedFiles\"
    End Sub
End Class

Class Info
    Public Property name As String
    Public Property age As Byte
    Public Property address As String


    Public Sub getInfo(ByVal txtbox1 As String, ByVal txtbox2 As Byte, ByVal txtbox3 As String)

        name = txtbox1
        age = txtbox2
        address = txtbox3


    End Sub
End Class
Imports System.Data.SqlClient

Public Class bid_history
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user_email = Request.Cookies("user").Item("email")
        Dim conn_string As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
        Dim conn As New SqlConnection(conn_string)
        conn.Open()
        Dim str_sql = "Select uid from users where email = '" & user_email & "'"
        Dim cmd = New SqlCommand(str_sql, conn)
        Dim uid = Convert.ToInt32(cmd.ExecuteScalar())
        SqlDataSource1.SelectCommand = "select * from bids inner join items on bids.item_id = items.item_id where bids.uid='" & uid & "'"

    End Sub

End Class
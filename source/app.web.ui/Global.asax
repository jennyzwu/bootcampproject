<%@ Application Language="C#" %>
<%@ Import Namespace="app.utility.service_locator" %>
<%@ Import Namespace="app.web.core" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        Dependencies.resolution = d => new Container(d);
    }

</script>

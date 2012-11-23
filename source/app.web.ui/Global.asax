<%@ Application Language="C#" %>
<%@ Import Namespace="app.utility.service_locator" %>
<%@ Import Namespace="app.web.core" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        var container = new Container(new DependencyMapping(), new ReflectionBasedContractDependenciesFinder());
        
        Dependencies.resolution = ()=> container;
    }

    
    



</script>

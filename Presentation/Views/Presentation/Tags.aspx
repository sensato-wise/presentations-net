<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Presentation.Models.Tag>>" %>

<% foreach (var item in Model) { %>
    <%: item.Name %>
<% } %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyUILearn.Controllers
{
    public class PrimController : Controller
    {
        //
        // GET: /Prim/
        public ActionResult Index()
        {
            string str = String.Empty;
            str = @"[{
    ""id"":1,
    ""text"":""Folder1"",
    ""iconCls"":""icon-save"",
    ""children"":[{
        ""text"":""File1"",
        ""checked"":true
    },{
        ""text"":""Books"",
        ""state"":""open"",
        ""attributes"":{
            ""url"":""/demo/book/abc"",
            ""price"":100
        },
        ""children"":[{
            ""text"":""PhotoShop"",
            ""checked"":true
        },{
            ""id"": 8,
            ""text"":""Sub Bookds"",
            ""state"":""closed""
        }]
    }]
},{
    ""iconCls"":""icon-ok"",
    ""text"":""Languages"",
    ""state"":""closed"",
    ""children"":[{
    ""iconCls"":""icon-ok"",
        ""text"":""Java""
    },{
        ""text"":""C#""
    }]
}]";
            return Content(str);
        }
	}
}
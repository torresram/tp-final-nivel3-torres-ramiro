﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = ResolveUrl("~/Images/userDefault.png");
            
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
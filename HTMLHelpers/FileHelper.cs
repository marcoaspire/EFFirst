﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFFirst.HTMLHelpers
{
    public static class FileHelper
    {
        public static MvcHtmlString File(this HtmlHelper htmlHelper, string CssClassname)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "file");
            tag.MergeAttribute("id", "Image");
            tag.MergeAttribute("name", "picture");

            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}
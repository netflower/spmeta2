﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMeta2.Definitions
{
    /// <summary>
    /// Allows to define and deploy SharePoint managed path.
    /// </summary>
    public class PrefixDefinition : DefinitionBase
    {
        #region properties

        /// <summary>
        /// Path of the target managed path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// PrefixType of the target manages path.
        /// 
        /// BuiltInPrefixTypes class can be used to utilize out of the box SharePoint prefix types.
        /// </summary>
        public string PrefixType { get; set; }

        #endregion
    }
}
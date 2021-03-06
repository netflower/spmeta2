﻿using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using SPMeta2.Definitions.Base;
using SPMeta2.Utils;

namespace SPMeta2.Definitions
{
    /// <summary>
    /// Allows to define and deploy SharePoint managed path.
    /// </summary>
    /// 

    [SPObjectTypeAttribute(SPObjectModelType.SSOM, "Microsoft.SharePoint.Administration.SPPrefix", "Microsoft.SharePoint")]

    [DefaultRootHostAttribute(typeof(WebApplicationDefinition))]
    [DefaultParentHostAttribute(typeof(WebApplicationDefinition))]

    [Serializable]
    [ExpectWithExtensionMethod]
    public class PrefixDefinition : DefinitionBase
    {
        #region properties

        /// <summary>
        /// Path of the target managed path.
        /// </summary>
        /// 
        [ExpectValidation]
        public string Path { get; set; }

        /// <summary>
        /// PrefixType of the target manages path.
        /// 
        /// BuiltInPrefixTypes class can be used to utilize out of the box SharePoint prefix types.
        /// </summary>
        /// 
        [ExpectValidation]
        public string PrefixType { get; set; }

        #endregion

        #region methods

        public override string ToString()
        {
            return new ToStringResult<PrefixDefinition>(this)
                          .AddPropertyValue(p => p.Path)
                          .AddPropertyValue(p => p.PrefixType)

                          .ToString();
        }

        #endregion
    }
}

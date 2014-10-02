﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPMeta2.Common
{
    /// <summary>
    /// Internal usage only.
    /// </summary>
    public class ModelWeigh
    {
        #region constructors

        public ModelWeigh()
        {

        }

        public ModelWeigh(Type model, IEnumerable<Type> childModels)
        {
            Model = model;
            ChildModels = new Dictionary<Type, int>();

            var index = 0;

            foreach (var childModel in childModels)
            {
                if (!ChildModels.ContainsKey(childModel))
                {
                    index += 100;
                    ChildModels.Add(childModel, index);
                }
            }
        }

        #endregion

        #region properties

        public Type Model { get; set; }
        public Dictionary<Type, int> ChildModels { get; set; }

        #endregion
    }
}
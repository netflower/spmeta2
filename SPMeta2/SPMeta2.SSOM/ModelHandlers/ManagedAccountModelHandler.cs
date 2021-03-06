﻿using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Services;
using SPMeta2.SSOM.ModelHosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;
//using System.Threading.Tasks;
using SPMeta2.Utils;

using SPMeta2.Common;

namespace SPMeta2.SSOM.ModelHandlers
{
    public class ManagedAccountModelHandler : SSOMModelHandlerBase
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(ManagedAccountDefinition); }
        }

        #endregion

        #region methods

        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            var farmModelHost = modelHost.WithAssertAndCast<FarmModelHost>("modelHost", value => value.RequireNotNull());
            var managedAccountDefinition = model.WithAssertAndCast<ManagedAccountDefinition>("model", value => value.RequireNotNull());

            DeployManagedAccount(modelHost, farmModelHost.HostFarm, managedAccountDefinition);
        }

        protected SPManagedAccount GetManagedAccount(SPFarm farm, ManagedAccountDefinition managedAccountDefinition)
        {
            var loginName = managedAccountDefinition.LoginName;
            var accounts = new SPFarmManagedAccountCollection(farm);

            SPManagedAccount currentAccount = null;

            try
            {
                currentAccount = accounts[loginName];
            }
            catch (Exception ex)
            { }

            return currentAccount;
        }

        private void DeployManagedAccount(object modelHost, SPFarm farm, ManagedAccountDefinition managedAccountDefinition)
        {
            var currentAccount = GetManagedAccount(farm, managedAccountDefinition);

            var loginName = managedAccountDefinition.LoginName;
            var accounts = new SPFarmManagedAccountCollection(farm);

            InvokeOnModelEvent(this, new ModelEventArgs
            {
                CurrentModelNode = null,
                Model = null,
                EventType = ModelEventType.OnProvisioning,
                Object = currentAccount,
                ObjectType = typeof(SPManagedAccount),
                ObjectDefinition = managedAccountDefinition,
                ModelHost = modelHost
            });


            if (currentAccount == null)
            {
                TraceService.Information((int)LogEventId.ModelProvisionProcessingNewObject, "Processing new managed account");

                currentAccount = accounts.FindOrCreateAccount(loginName);

                InvokeOnModelEvent(this, new ModelEventArgs
                {
                    CurrentModelNode = null,
                    Model = null,
                    EventType = ModelEventType.OnProvisioned,
                    Object = currentAccount,
                    ObjectType = typeof(SPManagedAccount),
                    ObjectDefinition = managedAccountDefinition,
                    ModelHost = modelHost
                });

                currentAccount.Update();
            }
            else
            {
                TraceService.Information((int)LogEventId.ModelProvisionProcessingExistingObject, "Processing existing managed account");

                InvokeOnModelEvent(this, new ModelEventArgs
                {
                    CurrentModelNode = null,
                    Model = null,
                    EventType = ModelEventType.OnProvisioned,
                    Object = currentAccount,
                    ObjectType = typeof(SPManagedAccount),
                    ObjectDefinition = managedAccountDefinition,
                    ModelHost = modelHost
                });

                currentAccount.Update();
            }
        }

        #endregion
    }
}

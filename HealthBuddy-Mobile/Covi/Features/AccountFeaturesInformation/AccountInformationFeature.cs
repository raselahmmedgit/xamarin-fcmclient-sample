﻿// =========================================================================
// Copyright 2020 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using System;
using Covi.Features.Registry;
using Prism.Ioc;
using Prism.Modularity;

namespace Covi.Features.AccountFeaturesInformation
{
    public class AccountInformationFeature : FeatureBase, IFeature
    {
        public override void Register(IContainerProvider registry, IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Features.AccountFeaturesInformation.AccountInformationModule>(InitializationMode.WhenAvailable);

            moduleCatalog.AddModule<Features.AccountFeaturesInformation.Modules.AnonymousAccountInformationModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<Features.AccountFeaturesInformation.Modules.RegisteredAccountInformationModule>(InitializationMode.WhenAvailable);
        }
    }
}

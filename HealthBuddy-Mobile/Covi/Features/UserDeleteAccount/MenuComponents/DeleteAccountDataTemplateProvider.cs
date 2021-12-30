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

using Covi.Features.ComponentsManagement;
using System;
using Xamarin.Forms;

namespace Covi.Features.UserDeleteAccount.MenuComponents
{
    public class DeleteAccountDataTemplateProvider : CompositeDataTemplateProvider
    {
        protected override Func<View> GetViewProvider(IComponent component)
        {
            if (component is DeleteAccountMenuItemViewModel)
            {
                return () => new Menu.Components.MenuItem();
            }

            return null;
        }
    }
}

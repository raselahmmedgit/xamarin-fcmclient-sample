// =========================================================================
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

namespace Covi.Features.ApplyCode
{
    public static class ApplyCodeTriggers
    {
        public static class Navigation
        {
            public static class In
            {
                public static Type StartApplyCodeActionHandler { get; } = typeof(StartApplyCodeActionHandler);
            }

            public static class Out
            {
                public static Type CodeAppliedActionHandler { get; } = typeof(CodeAppliedActionHandler);
            }
        }
    }
}

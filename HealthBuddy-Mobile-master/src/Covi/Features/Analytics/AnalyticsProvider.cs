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

namespace Covi.Features.Analytics
{
    public static class AnalyticsProvider
    {
        private static IAnalyticsService DefaultInstanceProvider => new Internal.DefaultAnalyticsService();

        private static IAnalyticsService _instanceProvider;

        public static IAnalyticsService Instance
        {
            get
            {
                if (_instanceProvider == null)
                {
                    return DefaultInstanceProvider;
                }

                return _instanceProvider;
            }
        }

        public static void SetProvider(IAnalyticsService provider)
        {
            _instanceProvider = provider;
        }
    }
}

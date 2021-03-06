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

namespace Covi.Features.OnBoarding
{
    public class InstructionItem
    {
        public InstructionItem(string instructionText, string instructionImageUrl = null)
        {
            InstructionText = instructionText;
            InstructionImageUrl = instructionImageUrl;
        }

        public string InstructionText { get; }

        public string InstructionImageUrl { get; }
    }
}

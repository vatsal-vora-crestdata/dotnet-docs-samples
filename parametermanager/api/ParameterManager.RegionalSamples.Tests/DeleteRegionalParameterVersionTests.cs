/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Google.Cloud.ParameterManager.V1;

[Collection(nameof(ParameterManagerRegionalFixture))]
public class DeleteRegionalParameterVersionTests
{
    private readonly ParameterManagerRegionalFixture _fixture;
    private readonly DeleteRegionalParameterVersionSample _sample;

    public DeleteRegionalParameterVersionTests(ParameterManagerRegionalFixture fixture)
    {
        _fixture = fixture;
        _sample = new DeleteRegionalParameterVersionSample();
    }

    [Fact]
    public void DeleteRegionalParameterVersion()
    {
        ParameterVersionName parameterVersionName = _fixture.ParameterVersionNameToDelete;
        _sample.DeleteRegionalParameterVersion(projectId: parameterVersionName.ProjectId, locationId: ParameterManagerRegionalFixture.LocationId, parameterId: parameterVersionName.ParameterId, versionId: parameterVersionName.ParameterVersionId);

        ParameterManagerClient client = ParameterManagerClient.Create();
        Assert.Throws<Grpc.Core.RpcException>(() => client.GetParameterVersion(parameterVersionName));
    }
}

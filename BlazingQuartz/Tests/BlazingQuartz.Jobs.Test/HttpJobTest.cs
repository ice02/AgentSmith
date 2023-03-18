﻿using System.Net;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using BlazingQuartz.Test.Shared;
using Moq;
using Moq.Protected;
using RichardSzalay.MockHttp;
using BlazingQuartz.Jobs.Abstractions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingQuartz.Jobs.Test;

public class HttpJobTest
{
    [Theory, HttpAutoData]
    public async Task Execute_Get([Frozen] MockHttpMessageHandler handler,
        [Frozen] Mock<IDataMapValueResolver> dmvResolverMock,
        HttpJob sut, Uri testUri, string expectedResult)
    {
        // ARRANGE
        handler.When(HttpMethod.Get, testUri.ToString())
               .Respond(HttpStatusCode.OK, new StringContent(expectedResult));
        dmvResolverMock.Setup(r => r.Resolve(It.IsAny<DataMapValue?>()))
            .Returns<DataMapValue?>(dmv => dmv?.Value);
        var jobContext = TestUtils.NewJobExecutionContextFor(sut);
        var dmw = new DataMapValue(DataMapValueType.InterpolatedString, testUri.ToString(), 1);
        jobContext.MergedJobDataMap.Put(HttpJob.PropertyRequestUrl, dmw.ToString());
        jobContext.MergedJobDataMap.Put(HttpJob.PropertyRequestAction, HttpAction.Get.ToString());

        // ACT
        await sut.Execute(jobContext);

        // ASSERT
        jobContext.Result.Should().NotBeNull();
        jobContext.Result.Should().Be(expectedResult);
        jobContext.GetReturnCode().Should().Be(((int)HttpStatusCode.OK).ToString());
        jobContext.GetIsSuccess().Should().BeTrue();
    }
}

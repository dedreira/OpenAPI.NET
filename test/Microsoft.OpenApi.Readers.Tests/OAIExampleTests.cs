﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi;
using Xunit;
using Microsoft.OpenApi.Readers;
using Microsoft.OpenApi.Readers.YamlReaders;

namespace OpenApiTests
{
    public class OAIExampleTests
    {
        HttpClient client;
        public OAIExampleTests()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://raw.githubusercontent.com/OAI/OpenAPI-Specification/OpenAPI.next/examples/v3.0/");
        }
        [Fact]
        public async Task SimplePetStore()
        {
            var stream = await client.GetStreamAsync("petstore.yaml");
            var openApiDoc = new OpenApiStreamReader().Read(stream, out var context);

            Assert.Empty(context.Errors);
        }

        [Fact]
        public async Task UberExample()
        {
            var stream = await client.GetStreamAsync("uber.yaml");
            var openApiDoc = new OpenApiStreamReader().Read(stream, out var context);

            Assert.Empty(context.Errors);
        }

        [Fact]
        public async Task PetStoreExpandedExample()
        {
            var stream = await client.GetStreamAsync("petstore-expanded.yaml");
            var openApiDoc = new OpenApiStreamReader().Read(stream, out var context);

            Assert.Empty(context.Errors);
        }

        [Fact(Skip = "Example is not updated yet")]
        public async Task ApiWithExamples()
        {
            var stream = await client.GetStreamAsync("api-with-examples.yaml");
            var openApiDoc = new OpenApiStreamReader().Read(stream, out var context);

            Assert.Empty(context.Errors);
        }
    }
}

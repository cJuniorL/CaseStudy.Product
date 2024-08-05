using AutoMapper;
using CaseStudy.Product.Application.Abstractions;
using CaseStudy.Product.Application.UseCases;
using CaseStudy.Product.Contracts.Requests;
using CaseStudy.Product.Contracts.Responses;
using CaseStudy.Product.Domain.Models;
using CaseStudy.Product.Domain.Repositories;
using CaseStudy.Product.UnitTest.Builders;
using FluentValidation;
using MassTransit;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaseStudy.Product.UnitTest.Application.UseCases
{
    public class PostProductUseCaseTest
    {
        private AutoMocker _autoMocker;

        public PostProductUseCaseTest()
        {
            _autoMocker = new AutoMocker();
        } 

        private void Arrange(Action<AutoMocker> action) {
            var request = new PostProductRequestBuilder().Build();
            _autoMocker.Use(request);

            var response = new PostProductResponse();
            _autoMocker.Use(response);

            var produtoEntity = new ProductEntity();
            _autoMocker.Use(produtoEntity);

            var cancellationToken = new CancellationToken();
            _autoMocker.Use(cancellationToken);

            action(_autoMocker);

            _autoMocker.GetMock<ICancellationTokenAcessor>().Setup(s => s.Token).Returns(cancellationToken);
            _autoMocker.GetMock<IMapper>().Setup(m => m.Map<ProductEntity>(It.IsAny<PostProductRequest>())).Returns(produtoEntity);
            _autoMocker.GetMock<IMapper>().Setup(m => m.Map<PostProductResponse>(It.IsAny<PostProductRequest>())).Returns(response);

        }

        private async Task<PostProductResponse> Act() {
            var postProductUseCase = _autoMocker.CreateInstance<PostProductUseCase>();
            var postProductRequest = _autoMocker.Get<PostProductRequest>();
            return await postProductUseCase.ExecuteAsync(postProductRequest);
        }


        private void Assert(Action<AutoMocker> action)
        {
            action(_autoMocker);
        }

        [Fact]
        public async Task PostProductUseCase_ExecuteAsync_ShouldMapProductEntityOnce()
        {
            Arrange(_ =>
            {
            });
            var act = await Act();
            
            Assert(_ => {
                var request = _autoMocker.Get<PostProductRequest>();
                _.Verify<IMapper>(v => v.Map<ProductEntity>(It.Is<PostProductRequest>(r => r == request)), Times.Once);
            });
        }


        [Fact]
        public async Task PostProductUseCase_ExecuteAsync_ShouldMapProductResponseOnce()
        {
            Arrange(_ =>
            {
            });
            var act = await Act();

            Assert(_ => {
                var product = _autoMocker.Get<ProductEntity>();
                _.Verify<IMapper>(v => v.Map<PostProductResponse>(It.Is<ProductEntity>(r => r == product)), Times.Once);
            });
        }

        [Fact]
        public async Task PostProductUseCase_ExecuteAsync_ShouldCallInsertOnce()
        {
            Arrange(_ =>
            {
            });
            var act = await Act();

            Assert(_ => {
                var product = _autoMocker.Get<ProductEntity>();
                var cancellationToken = _autoMocker.Get<CancellationToken>();
                _.Verify<IProductRepository>(v => v.InsertAsync(
                    It.Is<ProductEntity>(r => r == product), It.Is<CancellationToken>(c => c == cancellationToken)), Times.Once);
            });
        }

        [Fact]
        public async Task PostProductUseCase_ExecuteAsync_RequestInvalidThorwException()
        {
            Arrange(_ =>
            {
            });
            var act = await Act();

            Assert(_ => {
                var product = _autoMocker.Get<ProductEntity>();
                var cancellationToken = _autoMocker.Get<CancellationToken>();
                _.Verify<ITopicProducer<ProductEntity>>(v => v.Produce(
                    It.Is<ProductEntity>(r => r == product), It.Is<CancellationToken>(c => c == cancellationToken)), Times.Once);
            });
        }

    }
}

using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.BusinessLogic.Services;
using Banks.DataAccess.Interfaces;
using Banks.Entities;
using Banks.Entities.Enums;
using Banks.ViewModels.ViewModels.Account;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.BusinessLogicTests
{
    public class AccountServiceTests
    {
        private Mock<IMapper> mockMapper;
        private Mock<IAccountRepository> accountRepoMock;
        private IAccountService accountService;

        [SetUp]
        public void Setup()
        {
            accountRepoMock = new Mock<IAccountRepository>();
            mockMapper = new Mock<IMapper>();
            accountService = new AccountService(accountRepoMock.Object, mockMapper.Object);
        }

        [Test]
        public async Task GetbyId_GetValidId_Entity()
        {
            var entity = new Account() { Id = 1, ClientId = 1, Currency = Entities.Enums.Currencies.Uah, Number = "123" };
            var viewModel = new GetByIdAccountViewModel() { Id = 1 };
            mockMapper.Setup(x => x.Map<Account, GetByIdAccountViewModel>(It.IsAny<Account>()))
                    .Returns(viewModel);
            accountRepoMock.Setup(x => x.GetById(It.Is<int>(i => i > 0)))
            .Returns(Task.FromResult(entity));
            var result = await accountService.GetById<GetByIdAccountViewModel>(1);
            Assert.AreEqual(result, viewModel);
        }

        [Test]
        public async Task GetbyId_GotNonExistentId_Exception()
        {
            var entity = new Account() { Id = 1 };
            accountRepoMock.Setup(x => x.GetById(It.Is<int>(i => i > 1000)))
            .Returns(Task.FromResult<Account>(null));
            Func<Task> act = async () => await accountService.GetById<GetByIdAccountViewModel>(2000);
            await act.Should().ThrowAsync<ArgumentException>().WithMessage("Such entity not found!");
        }

        [Test]
        public async Task GetByCurrency_GotExistentParams_ViewModelCount1()
        {
            IEnumerable<Account> entities = new List<Account>(){
                new Account{Id=1, Client=new Client(){Id=1, BankId=1 }, Currency=Currencies.Rub },
                new Account{Id=2, Client=new Client(){Id=2, BankId=2 }, Currency=Currencies.Uah }
            };
            var items = new List<AccountGetAllAccountViewModelItem>()
            {
                  new AccountGetAllAccountViewModelItem(){Id=1, Currency=Currencies.Uah, BankId=1 },
                  new AccountGetAllAccountViewModelItem(){Id=2, BankId=2, Currency=Currencies.Uah }
            };
            accountRepoMock.Setup(x => x.GetAll())
        .Returns(Task.FromResult(entities));
            mockMapper.Setup(x => x.Map<List<AccountGetAllAccountViewModelItem>>(It.IsAny<List<Account>>()))
                      .Returns(items);
            var result = await accountService.GetByCurrency(1, 1);
            result.Count.Should().Be(1);
        }

        [Test]
        public async Task GetByCurrency_GotNotExistentParams_ListViewModelCount0()
        {
            IEnumerable<Account> entities = new List<Account>();
            var items = new List<AccountGetAllAccountViewModelItem>();

            accountRepoMock.Setup(x => x.GetAll())
        .Returns(Task.FromResult(entities));
            mockMapper.Setup(x => x.Map<List<AccountGetAllAccountViewModelItem>>(It.IsAny<List<Account>>()))
                      .Returns(items);
            var result = await accountService.GetByCurrency(1, 1);
            result.Count.Should().Be(0);
        }

        [Test]
        public async Task GetClientAccountsByCode_GotExistentParams_ViewModelCount1()
        {
            IEnumerable<Account> entities = new List<Account>(){
                new Account{Id=1, Client=new Client(){Id=1, BankId=1, Code="123456" } }
            };
            var items = new List<AccountGetAllAccountViewModelItem>()
            {
                  new AccountGetAllAccountViewModelItem(){Id=1, Code="123456", BankId=1 }
            };
            accountRepoMock.Setup(x => x.GetByClientCode(It.Is<int>(x => x > 0), It.IsAny<string>()))
        .Returns(Task.FromResult(entities));
            mockMapper.Setup(x => x.Map<List<AccountGetAllAccountViewModelItem>>(It.IsAny<List<Account>>()))
                      .Returns(items);
            var result = await accountService.GetClientAccountsByCode(1, "123456");
            result.Count.Should().Be(1);
        }

        [Test]
        public async Task GetClientAccountsByCode_GotNotExistentParams_ViewModelCount0()
        {
            IEnumerable<Account> entities = new List<Account>();
            var items = new List<AccountGetAllAccountViewModelItem>();

            accountRepoMock.Setup(x => x.GetAll())
        .Returns(Task.FromResult(entities));
            mockMapper.Setup(x => x.Map<List<AccountGetAllAccountViewModelItem>>(It.IsAny<List<Account>>()))
                      .Returns(items);
            var result = await accountService.GetClientAccountsByCode(1, "123456");
            result.Count.Should().Be(0);
        }

        [Test]
        public async Task Update_ModelWithExistentId_NoException()
        {
            UpdateAccountViewModel viewModel = new UpdateAccountViewModel() { Id = 1 };
            var entity = new Account() { Id = 1 };
            accountRepoMock.Setup(x => x.GetById(viewModel.Id))
        .Returns(Task.FromResult(entity));
            mockMapper.Setup(x => x.Map<UpdateAccountViewModel, Account>(viewModel, entity))
                      .Returns(entity);
            Func<Task> fanc = async () => await accountService.Update(viewModel);
            await fanc.Should().NotThrowAsync();
        }

        [Test]
        public async Task Update_ModelWithNotExistentId_Exception()
        {
            UpdateAccountViewModel viewModel = new UpdateAccountViewModel() { Id = 120 };
            accountRepoMock.Setup(x => x.GetById(It.Is<int>(x=>x>0)))
        .Returns(Task.FromResult<Account>(null));
            Func<Task> fanc = async () => await accountService.Update(viewModel);
            await fanc.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task Delete_GetExistentId_NotException()
        {
            var entity = new Account() { Id = 1, ClientId = 1, Currency = Entities.Enums.Currencies.Uah, Number = "123" };
                       
            accountRepoMock.Setup(x => x.GetById(It.Is<int>(i => i > 0)))
            .Returns(Task.FromResult(entity));
           
            Func<Task> fanc = async () => await accountService.Delete(entity.Id);
            await fanc.Should().NotThrowAsync();
        }

        [Test]
        public async Task Delete_GetNonExistentId_Exception()
        {
            accountRepoMock.Setup(x => x.GetById(It.Is<int>(i => i > 0)))
            .Returns(Task.FromResult<Account>(null));

            Func<Task> fanc = async () => await accountService.Delete(1);
            await fanc.Should().ThrowAsync<ArgumentException>().WithMessage("Cannot delete null entity.");
        }

        [Test]
        public async Task Create_GetModelWithLinksOnExistentId_NotException()
        {
            var entityToInsert = new Account() { ClientId = 1, Currency = Currencies.Uah, Number = "Uah1111111" };
            var createAccountViewModel = new CreateAccountViewModel() { BankId = 1, ClientId = 1, CurrencyCode = 1, Number = 1111111 };            
            mockMapper.Setup(x => x.Map<Account>(It.Is<CreateAccountViewModel>(x=>x==createAccountViewModel)))
                .Returns(entityToInsert);
            accountRepoMock.Setup(x => x.Insert(entityToInsert)).Returns(Task.FromResult(entityToInsert.Id));
            var result = await accountService.Create(createAccountViewModel);
            result.Should().Be(0);
        }

        [Test]
        public async Task Create_GetValidViewModel_RepositoryMethodsCalled()
        {
            var entityToInsert = new Account() { ClientId = 11, Currency = Currencies.Uah, Number = "Uah1111111" };
            var createAccountViewModel = new CreateAccountViewModel() { BankId = 1, ClientId = 11, CurrencyCode = 1, Number = 1111111 };
            mockMapper.Setup(x => x.Map<Account>(It.Is<CreateAccountViewModel>(x => x == createAccountViewModel)))
                .Returns(entityToInsert);
            await accountService.Create(createAccountViewModel);           
            accountRepoMock.Verify(x => x.Insert(It.IsAny<Account>()), Times.Once);
            accountRepoMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}

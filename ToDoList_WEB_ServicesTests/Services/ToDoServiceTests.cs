//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ToDoList_WEB_Services.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ToDoList_WEB_Entity.Models;
//using ToDoList_WEB_Repositories.Interfaces;
//using ToDoList_WEB_Repositories.Repositories;
//using Microsoft.Extensions.Configuration;
//using ToDoList_WEB_Domain.DomainModels;

//namespace ToDoList_WEB_Services.Services.Tests
//{
//    [TestClass()]
//    public class ToDoServiceTests
//    {
//        private ToDoService _toDoService;
//        private UserService _userService;
//        private IRepositoryBase<User> _userRepositoryBase;
//        private IRepositoryBase<ToDo> _toDoRepositoryBase;
//        private IConfiguration _configuration;

//        private ToDoDTO _toDo;
//        private UserDTO _user;

//        [TestInitialize]
//        public void Initialize()
//        {
//            string name = Guid.NewGuid().ToString();
//            string login = Guid.NewGuid().ToString();
//            string email = Guid.NewGuid().ToString();
//            string password = Guid.NewGuid().ToString();

//            _user = new UserDTO { Name = name, Login=login, Email=email, Password=password };

//            _userRepositoryBase = new SQLiteRepositroy<User>();
//            _toDoRepositoryBase = new SQLiteRepositroy<ToDo>();
//            _toDoService = new ToDoService();
//            _userService = new UserService(_configuration);
//        }

//        [TestMethod()]
//        public async Task AddNewToDoTest()
//        {
//            // arrange

//            var topicToDo = Guid.NewGuid().ToString();
//            var toDo = new AddToDoDTO { login=_user.Login, topic=topicToDo};

//            // act

//            await _userService.AddNewUserAsync(_user);
//            await _toDoService.AddNewToDoAsync(toDo);

//            var toDoExcept = await _toDoRepositoryBase.FindAsync(t=>t.Topic == topicToDo && t.User.Login == _user.Login);

//            // assert

//            Assert.IsNotNull(toDoExcept);
//        }

//        [TestMethod()]
//        public async Task ArchivateToDoTest()
//        {
//            // arrange


//            // act

//            await _userService.AddNewUserAsync(_user);
//            await _toDoService.ArchivateToDoAsync();

//            // assert
//        }

//        [TestMethod()]
//        public void DoneToDoTest()
//        {
//            Assert.Fail();
//        }

//        [TestMethod()]
//        public void DeleteToDoTest()
//        {
//            Assert.Fail();
//        }


//        [TestCleanup()]
//        public void Cleanup()
//        {
//            _userRepositoryBase.RemoveAsync();
//        }
//    }
//}
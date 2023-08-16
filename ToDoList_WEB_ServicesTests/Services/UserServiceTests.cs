//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ToDoList_WEB_Entity.Models;
//using ToDoList_WEB_Repositories.Interfaces;
//using ToDoList_WEB_Repositories.Repositories;

//namespace ToDoList_WEB_Services.Services.Tests
//{
//    [TestClass()]
//    public class UserServiceTests
//    {
//        private User _user;
//        private UserService _userService;
//        private IRepositoryBase<User> _repositoryBase;


//        [TestInitialize]
//        public void Initialize()
//        {
//            string name = Guid.NewGuid().ToString();
//            string login = Guid.NewGuid().ToString();
//            string email = Guid.NewGuid().ToString();
//            string password = Guid.NewGuid().ToString();

//            _user= new User(name, login, email, password);
//            _userService = new UserService();
//        }


//        [TestMethod()]
//        public async Task AddNewUserTest_DataForAddNewUser_NewUser()
//        {
//            // arrange
//            // act

//            bool isCreated = await _userService.AddNewUserAsync(_user);

//            // assert

//            Assert.IsTrue(isCreated);
//        }

//        [TestMethod()]
//        public async Task AddNewUserTest_Null_ArgumentNullException()
//        {
//            // arrange
//            // act
//            // assert
//            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _userService.AddNewUserAsync(null));
//        }

//        [TestMethod()]
//        public async Task AddNewUserTest_AddExistingLogin_Exception()
//        {
//            // arrange
//            // act

//            bool isCreated = await _userService.AddNewUserAsync(_user);

//            // assert

//            Assert.IsTrue(isCreated);
//            await Assert.ThrowsExceptionAsync<Exception>(async () => await _userService.AddNewUserAsync(_user));
//        }


//        [TestMethod()]
//        public async Task FindUserTest_DataForFindExistingUser_User()
//        {
//            // arrange
//            // act

//            await _userService.AddNewUserAsync(_user);
//            User foundUser = await _userService.FindUserAsync(_user.Login, _user.Password);

//            // assert

//            Assert.IsNotNull(foundUser);
//            if (foundUser.Login != _user.Login)
//            {
//                Assert.Fail("User wasn't found.");
//            }
//        }
        
//        [TestMethod()]
//        public async Task FindUserTest_EmptyInputData_ArgumentNullException()
//        {
//            // arrange
//            // act
//            // assert
//            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async ()=> await _userService.FindUserAsync("", ""));
//        }

//        [TestMethod()]
//        public async Task FindUserTest_FindNonExistingUser_EmptyOutputUser()
//        {
//            // arrange
//            // act

//            User foundUser = await _userService.FindUserAsync(_user.Login, _user.Password);

//            // assert

//            Assert.IsNull(foundUser);
//        }


//        [TestCleanup()]
//        public void Cleanup()
//        {
//            _repositoryBase = new SQLiteRepositroy<User>();

//            _repositoryBase.RemoveAsync(_user);
//        }
//    }
//}
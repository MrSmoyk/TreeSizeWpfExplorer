using FluentAssertions;
using Services.Models;
using Services.Services;
using System.Reflection;

namespace Service.Tests
{
    public class DirectoryServiceTests
    {
        private readonly IDirectoryService Service;

        public DirectoryServiceTests()
        {
            Service = new DirectoryService();
        }

        [Fact]
        public async void GetAllEntytys_WithNullPath_Fail()
        {
            string testPath = null;

            var result = await Service.GetAllEntytys(testPath);

            BaseEntyty expected = new BaseEntyty();

            result.Should().NotBeNull();
            result.Should().BeOfType<BaseEntyty>();
            result.IsFile.Should().BeFalse();
            result.Name.Should().BeNull();
            result.Size.Equals(expected.Size);
            result.Modificated.Equals(expected.Modificated);
            result.AccessDenied.Equals(expected.AccessDenied);
            result.Allocated.Equals(expected.Allocated);
            result.Created.Equals(expected.Created);
            result.Modificated.Equals(expected.Modificated);
            result.SubEntytys.Equals(expected.SubEntytys);
            result.SubFilesCount.Equals(expected.SubFilesCount);
            result.SubFoldersCount.Equals(expected.SubFoldersCount);
        }

        [Fact]
        public async void GetAllEntytys_WithZeroPath_Fail()
        {
            string testPath = "";

            var result = await Service.GetAllEntytys(testPath);

            BaseEntyty expected = new BaseEntyty();

            result.Should().NotBeNull();
            result.Should().BeOfType<BaseEntyty>();
            result.IsFile.Should().BeFalse();
            result.Name.Should().BeNull();
            result.Size.Equals(expected.Size);
            result.Modificated.Equals(expected.Modificated);
            result.AccessDenied.Equals(expected.AccessDenied);
            result.Allocated.Equals(expected.Allocated);
            result.Created.Equals(expected.Created);
            result.Modificated.Equals(expected.Modificated);
            result.SubEntytys.Equals(expected.SubEntytys);
            result.SubFilesCount.Equals(expected.SubFilesCount);
            result.SubFoldersCount.Equals(expected.SubFoldersCount);
        }

        [Fact]
        public async void GetAllEntytys_WithDefaultFolder_Sucsess()
        {
            string testPath = ".";

            var result = await Service.GetAllEntytys(testPath);

            result.Should().NotBeNull();
            result.Should().BeOfType<BaseEntyty>();
            result.IsFile.Should().BeFalse();
            result.Name.Should().Be("net6.0-windows");
            result.AccessDenied.Should().BeFalse();
            result.SubFilesCount.Should().BePositive();
            result.SubFoldersCount.Should().BePositive();
            result.SubEntytys.Should().NotBeEmpty();
        }

        
        [Fact]
        public async void GetSubEntytys_Sucsess()
        {
            DirectoryInfo testDirectoryInfo = new DirectoryInfo(".");
            Type type = typeof(DirectoryService);

            object[] param = { testDirectoryInfo };

            var result = await (Task<BaseEntyty>)type.GetTypeInfo()
                .GetDeclaredMethod("GetSubEntytys").Invoke(Service, param);

            result.Should().NotBeNull();
            result.Should().BeOfType<BaseEntyty>();
            result.IsFile.Should().BeFalse();
            result.Name.Should().Be("net6.0-windows");
            result.AccessDenied.Should().BeFalse();
            result.SubFilesCount.Should().BePositive();
            result.SubFoldersCount.Should().BePositive();
            result.SubEntytys.Should().NotBeEmpty();

        }

        [Fact]
        public async void DirectoryProcessing_Sucsess()
        {
            DirectoryInfo testDirectoryInfo = new DirectoryInfo(".");
            Type type = typeof(DirectoryService);

            object[] param = { testDirectoryInfo };

            var result = await (Task<BaseEntyty>)type.GetTypeInfo()
                .GetDeclaredMethod("DirectoryProcessing").Invoke(Service, param);

            result.Should().NotBeNull();
            result.Should().BeOfType<BaseEntyty>();
            result.IsFile.Should().BeFalse();
            result.Name.Should().Be("net6.0-windows");
            result.AccessDenied.Should().BeFalse();
            result.SubFilesCount.Should().BePositive();
            result.SubFoldersCount.Should().BePositive();
            result.SubEntytys.Should().NotBeEmpty();

        }

        [Fact]
        public void AddSubDirectories_Sucsess()
        {
            DirectoryInfo testDirectoryInfo = new DirectoryInfo(".");
            BaseEntyty result = new BaseEntyty();

            Type type = typeof(DirectoryService);

            object[] param = { testDirectoryInfo, result };

            type.GetTypeInfo()
                .GetDeclaredMethod("AddSubDirectories").Invoke(Service, param);

            result.Should().NotBeNull();
            result.Should().BeOfType<BaseEntyty>();
            result.IsFile.Should().BeFalse();
            result.Name.Should().BeNull();
            result.AccessDenied.Should().BeFalse();
            result.SubFilesCount.Should().BePositive();
            result.SubFoldersCount.Should().BePositive();
            result.SubEntytys.Should().NotBeEmpty();

        }

        [Fact]
        public void AddSubFiles_Sucsess()
        {
            DirectoryInfo testDirectoryInfo = new DirectoryInfo(".");
            BaseEntyty result = new BaseEntyty();

            Type type = typeof(DirectoryService);

            object[] param = { testDirectoryInfo, result };

            type.GetTypeInfo()
                .GetDeclaredMethod("AddSubFiles").Invoke(Service, param);

            result.Should().NotBeNull();
            result.Should().BeOfType<BaseEntyty>();
            result.IsFile.Should().BeFalse();
            result.Name.Should().BeNull();
            result.AccessDenied.Should().BeFalse();
            result.SubFilesCount.Should().BePositive();
            result.SubFoldersCount.Should().Be(0);
            result.SubEntytys.Should().NotBeEmpty();

        }
    }
}
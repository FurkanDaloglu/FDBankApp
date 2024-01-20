using FDBankApp.Data.Entities;
using FDBankApp.Models;

namespace FDBankApp.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);
        UserListModel MapToUserList(ApplicationUser user);
    }
}

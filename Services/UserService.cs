using Tele2Task.Communication;
using Tele2Task.Models;
using Tele2Task.Repositories;
using Tele2Task.Tools;

namespace Tele2Task.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<User>> GetAll()
    {
        return _userRepository.GetAll();
    }

    public async Task<UserResponse> Get(int id)
    {
        try
        {
            var entity = await _userRepository.Get(id);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(entity);
        }
        catch (Tele2Exception ex)
        {
            return new UserResponse($"An error occurred when finding the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> Save(User user)
    {
        try
        {
            var entity = await _userRepository.Save(user);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(entity);
        }
        catch (Tele2Exception ex)
        {
            return new UserResponse($"An error occurred when saving the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> Update(User user)
    {
        try
        {
            var entity = await _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(entity);
        }
        catch (Tele2Exception ex)
        {
            return new UserResponse($"An error occurred when updating the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> Delete(int id)
    {
        try
        {
            var user = await _userRepository.Get(id);
            var entity = await _userRepository.Delete(user);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(entity);
        }
        catch (Tele2Exception ex)
        {
            return new UserResponse($"An error occurred when removing the user: {ex.Message}");
        }
    }
}
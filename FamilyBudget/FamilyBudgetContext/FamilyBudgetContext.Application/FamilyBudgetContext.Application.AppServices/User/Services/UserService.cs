﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Application.AppServices.Publishers;
using Common.Contracts.Publisher.Contracts.EmailSend;
using Common.Infrastucture.Infrastructure.Exception;
using FamilyBudgetContext.Application.AppServices.Category.Services;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Application.AppServices.User.Helpers;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.CreateDefaultCategories;
using FamilyBudgetContext.Contracts.Api.Contracts.User.ConfirmEmail;
using FamilyBudgetContext.Contracts.Api.Contracts.User.GetUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.LoginUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.PasswordRecovery;
using FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.UpdateUser;
using FamilyBudgetContext.Domain.Domain;
using Microsoft.Extensions.Configuration;

namespace FamilyBudgetContext.Application.AppServices.User.Services
{
    public class UserService : IUserService
    {
        private const string DefaultPhotoBase64 =
            "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";
        
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IEmailPublisher _emailPublisher;
        private readonly ICategoryService _categoryService;

        public UserService(
            IUserRepository userRepository, IConfiguration configuration, IMapper mapper, IEmailPublisher emailPublisher, ICategoryService categoryService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _emailPublisher = emailPublisher;
            _categoryService = categoryService;
        }

        public async Task<GetUserResponse> GetUser(GetUserRequest request, CancellationToken cancellation)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellation);
            return _mapper.Map<GetUserResponse>(user);
        }

        public Task<LoginUserResponse> LoginUser(LoginUserRequest request, CancellationToken cancellation)
        {
            var user = _userRepository
                .Where(x => x.Email.ToLower() == request.Email.ToLower())
                .FirstOrDefault();

            if (user == null || user.PasswordHash != request.Password.CreatePasswordHash())
            {
                throw new WrongDataException("Неверная почта или пароль");
            }

            if (!user.IsEmailConfirm)
            {
                throw new WrongDataException("Почта не потдвержена");
            }

            var response = _mapper.Map<LoginUserResponse>(user);
            response.RoomId = user.Rooms.FirstOrDefault()?.Id;
            response.Token = user.CreateJwtToken(_configuration);

            return Task.FromResult(response);
        }

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request, CancellationToken cancellation)
        {
            var usersWithEqualEmail = _userRepository.Where(x => x.Email == request.Email);

            var userWithEqualEmail = usersWithEqualEmail.FirstOrDefault();
            
            if (userWithEqualEmail?.IsEmailConfirm ?? false)
            {
                throw new WrongDataException("Пользователь с таким Email уже существует");
            }
            
            var confirmCode = UserHelper.GetConfirmCode();
            await _emailPublisher.PublishSendEmailAsync(new SendEmailRequest
            {
                Email = request.Email,
                Subject = "Подтверждение",
                Message = $"Ваш код {confirmCode}"
            });

            if (userWithEqualEmail == null)
            {
                var user = _mapper.Map<UserEntity>(request);
                user.Photo = DefaultPhotoBase64;
                user.IsEmailConfirm = false;
                user.ConfirmCode = confirmCode;
                user.Categories = _categoryService.CreateDefaultCategories(new CreateDefaultCategoriesRequest{UserId = 0} , cancellation).Result.DefaultCategories;
                var userId = await _userRepository.AddAsync(user, cancellation);
            }
            else
            {
                userWithEqualEmail.ConfirmCode = confirmCode;
                await _userRepository.UpdateAsync(userWithEqualEmail, cancellation);
            }
            
            return _mapper.Map<RegisterUserResponse>(_userRepository.Where(x => x.Email == request.Email).FirstOrDefault());
        }

        public async Task<ConfirmEmailResponse> ConfirmEmail(ConfirmEmailRequest request, CancellationToken cancellation)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellation);

            if (user.ConfirmCode != request.ConfirmCode)
                return new ConfirmEmailResponse
                {
                    IsEmailConfirm = false
                };
            
            user.ConfirmCode = string.Empty;
            user.IsEmailConfirm = true;
                
            await _userRepository.UpdateAsync(user, cancellation);
                
            return new ConfirmEmailResponse
            {
                IsEmailConfirm = true
            };

        }

        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request, CancellationToken cancellation)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellation);

            user.Email = request.Email ?? user.Email;
            user.Name = request.Name ?? user.Name;
            user.Photo = request.Photo ?? user.Photo;
            user.PasswordHash = string.IsNullOrEmpty(request.Password) ? user.PasswordHash : request.Password.CreatePasswordHash();
            
            await _userRepository.UpdateAsync(user, cancellation);

            return new UpdateUserResponse
            {
                Id = user.Id
            };
        }

        public async Task<PasswordRecoveryResponse> PasswordRecovery(PasswordRecoveryRequest requestRequest, CancellationToken cancellation)
        {
            var user = _userRepository.Where(x => x.Email == requestRequest.Email).FirstOrDefault();
            if (user == null)
            {
                throw new WrongDataException("Пользователь с таким Email не найден");
            }
            
            var confirmCode = UserHelper.GetConfirmCode();
            
            try
            {
                await _emailPublisher.PublishSendEmailAsync(new SendEmailRequest
                {
                    Email = user.Email,
                    Subject = "Востановление пароля",
                    Message = $"Ваш код {confirmCode}"
                });
            }
            catch (Exception e)
            {
                throw new SendEmailException($"Ошибка отправки сообщения на Email {e.Message}");
            }

            user.ConfirmCode = confirmCode;
            await _userRepository.UpdateAsync(user, cancellation);

            return new PasswordRecoveryResponse
            {
                UserId = user.Id
            };
        }
    }
}

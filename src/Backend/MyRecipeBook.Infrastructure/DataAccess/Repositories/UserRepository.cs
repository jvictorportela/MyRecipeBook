﻿using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly MyRecipeBookDbContext _context;

    public UserRepository(MyRecipeBookDbContext context)
    {
        _context = context;
    }

    public async Task Add(Domain.Entities.User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.Equals(email) && u.Active);
    }

    public async Task<User?> GetByEmailAndPassword(string email, string password)
    {
        return await _context
            .Users
            .AsNoTracking() //Quando não vai ser atualizada por regra de negócio
            .FirstOrDefaultAsync(user => user.Active && user.Email.Equals(email) && user.Password.Equals(password));
    }
}

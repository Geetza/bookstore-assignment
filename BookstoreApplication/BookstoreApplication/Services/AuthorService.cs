using AutoMapper;
using BookstoreApplication.Domain;
using BookstoreApplication.Domain.IRepositories;
using BookstoreApplication.DTOs.Response;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET ALL
        public async Task<PaginatedResultDto<AuthorDto>> GetPagedAuthorsAsync(int page, int pageSize)
        {
            var query = _authorRepository.GetAllAuthors();

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(author => new AuthorDto
                {
                    FullName = author.FullName,
                    Biography = author.Biography,
                    DateOfBirth = author.DateOfBirth
                })
                .ToListAsync();

            return new PaginatedResultDto<AuthorDto>(items, totalCount, page, pageSize);
        }


        // GET ONE
        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            
            var author = await _authorRepository.GetOneAuthorAsync(id);
            if (author == null)
                throw new NotFoundException(id);
            return author;
        }

        // ADD
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            return await _authorRepository.AddAuthorAsync(author);
        }

        // UPDATE
        public async Task<Author?> UpdateAuthorAsync(int id, Author author)
        {
            if (id != author.Id)
                throw new BadRequestException("Id value is invalid");
            var existingAuthor = await _authorRepository.GetOneAuthorAsync(id);
            if (existingAuthor == null)
            {
                throw new NotFoundException(id);
            }

            existingAuthor.FullName = author.FullName;
            existingAuthor.DateOfBirth = author.DateOfBirth;
            existingAuthor.Biography = author.Biography;
            existingAuthor.AuthorAwards = author.AuthorAwards;

            return await _authorRepository.UpdateAuthorAsync(existingAuthor);
        }

        // DELETE
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var existing = await _authorRepository.GetOneAuthorAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            return await _authorRepository.DeleteAuthorAsync(id);
        }
    }
}

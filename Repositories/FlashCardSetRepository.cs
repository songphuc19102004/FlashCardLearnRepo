﻿using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FlashCardSetRepository
    {
        private FlashCardLearnContext _context;

        public FlashCardSetRepository()
        {
            _context = new FlashCardLearnContext();
        }

        public async Task<IEnumerable<FlashCardSet>> GetFlashCardSetsAsync()
        {
            return await _context.FlashCardSets.ToListAsync();
        }

        public async Task<bool> UpdateAsync(FlashCardSet flashCardSet)
        {
            _context.Entry(flashCardSet).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> GetFlashCardCountForSetAsync(int flashcardsetId)
        {
            return await _context.FlashCards
                .Where(fc => fc.FlashcardsetId == flashcardsetId)
                .CountAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.ClientSdk
{
    public enum ErrorCodes
    {
        /// <summary>
        /// Invalid Book Name while creating book.
        /// </summary>
        InvalidBookName = 101,

        /// <summary>
        /// Invalid Author Name while creating author.
        /// </summary>
        InvalidAuthorName = 102,

        /// <summary>
        /// Duplicate Book by Title while creating book.
        /// </summary>
        DuplicateBookByTitle = 201,

        /// <summary>
        /// Duplicate Author by Title while creating Author.
        /// </summary>
        DuplicateAuthorByName = 202,

        /// <summary>
        /// Book was not found
        /// </summary>
        BookWasNotFound = 203,

        /// <summary>
        /// Author was not found
        /// </summary>
        AuthorWasNotFound = 204,

        /// <summary>
        /// Book was not created in database
        /// </summary>
        BookWasNotCreatedInDatabase = 205,

        /// <summary>
        /// Author was not created in database
        /// </summary>
        AuthorWasNotCreatedInDatabase = 206,

        /// <summary>
        /// Price of Book is incorrect
        /// </summary>
        InvalidBookPrice = 207,
    }
}

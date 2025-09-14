import React, { useEffect, useState } from 'react';
import { getBooks, deleteBook } from '../api/bookApi';
import SearchBook from './SearchBook';

const BookList = ({ onEdit }) => {
  const [books, setBooks] = useState([]);
  const [error, setError] = useState('');
  const [filteredBooks, setFilteredBooks] = useState([]);
  const [query, setQuery] = useState('');

  const loadBooks = async () => {
    try {
      const data = await getBooks();
      setBooks(data.books);
      setFilteredBooks(data.books);
      console.log('data.books : ', data.books)
    } catch (err) {
      setError(err.message || 'Failed to load books');
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('Are you sure you want to delete this book?')) {
      try {
        await deleteBook(id);
        loadBooks();
      } catch (err) {
        alert('Error deleting book: ' + err.message);
      }
    }
  };

  const handleSearch = (query) => {

    console.log(query)
    setQuery(query);
    if (!query) {
      setFilteredBooks(books);
    } else {
      const filtered = books.filter(
        (book) =>
          book.title.toLowerCase().includes(query.toLowerCase()) ||
          book.owner.toLowerCase().includes(query.toLowerCase())
      );
      console.log('filtered : ', filtered);
      setFilteredBooks(filtered);
    }
  };

  const handleCheckboxChange = (event) => {
    const checked = event.target.checked;
    
  };

  useEffect(() => {
    loadBooks();
  }, []);

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}

      {/* Search Component */}
      <SearchBook onSearch={handleSearch} />
      
      <ul>
        {filteredBooks.map((book) => (
          <li key={book.id}>
            <strong>{book.title}</strong> owned by {book.owner} 
            <input type='checkbox' checked={book.availability} onChange={handleCheckboxChange}/>
            {/* <button onClick={() => onEdit(book)}>Edit</button> */}
            <button onClick={() => handleDelete(book.id)}>Delete</button>
          </li>
        ))}
      </ul>
      <button onClick={() => onEdit(null)}>Add New Book</button>
    </div>
  );
};

export default BookList;

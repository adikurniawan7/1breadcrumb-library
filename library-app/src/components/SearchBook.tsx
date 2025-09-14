import React, { useState } from 'react';

const SearchBook = ({ onSearch }) => {
  const [query, setQuery] = useState('');

  const handleSearchChange = (event) => {
    setQuery(event.target.value);
    onSearch(event.target.value);
  };

  return (
    <div>
      Books Search: <input
        type="text"
        placeholder="Search by title or author"
        value={query}
        onChange={handleSearchChange}
      />
    </div>
  );
};

export default SearchBook;
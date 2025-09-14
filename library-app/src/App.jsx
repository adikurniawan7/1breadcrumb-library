import React, { useState } from 'react';
import BookList from './components/BookList';

const App = () => {
  const [editingBook, setEditingBook] = useState(null);

  return (
    <div style={{ padding: '20px' }}>
      <h1>Library</h1>
      {editingBook !== null ? (
        <BookForm book={editingBook} onDone={() => setEditingBook(null)} />
      ) : (
        <BookList onEdit={setEditingBook} />
      )}
    </div>
  );
};

export default App;

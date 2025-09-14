const API_BASE_URL = 'https://localhost:7220/book'; // adjust if needed

const headers = {
  'Content-Type': 'application/json'
};

export const getBooks = async () => {
  console.log(`${API_BASE_URL}/books`);
  const response = await fetch(`${API_BASE_URL}/books`);
  if (!response.ok) throw new Error('Failed to fetch books');
  return await response.json();
};

export const getBookById = async (id) => {
  const response = await fetch(`${API_BASE_URL}/${id}`);
  if (!response.ok) throw new Error('Book not found');
  return await response.json();
};

export const addBook = async (book) => {
  const response = await fetch(API_BASE_URL, {
    method: 'POST',
    headers,
    body: JSON.stringify(book)
  });
  if (!response.ok) throw new Error('Failed to add book');
  return await response.json();
};

export const updateBook = async (id, book) => {
  const response = await fetch(`${API_BASE_URL}/${id}`, {
    method: 'PUT',
    headers,
    body: JSON.stringify(book)
  });
  if (!response.ok) throw new Error('Failed to update book');
};

export const deleteBook = async (id) => {
  const response = await fetch(`${API_BASE_URL}/${id}`, {
    method: 'DELETE'
  });
  if (!response.ok) throw new Error('Failed to delete book');
};

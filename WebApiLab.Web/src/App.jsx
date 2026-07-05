import React, { useState, useEffect } from 'react';
import './App.css';

function App() {
  const [people, setPeople] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    fetch("http://localhost:5267/api/People")
      .then(response => {
        if (!response.ok) {
          throw new Error("Unable to retrieve people.");
        }

        return response.json();
      })
      .then(data => {
        setPeople(data);
        setLoading(false);
      })
      .catch(error => {
        setError(error.message);
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading...</p>;

  if (error) return <p>{error}</p>;

  return (
    <div>
      <h1>People</h1>

      {people.map(person => (
        <div key={person.id}>
          <h2>{person.name}</h2>
          <p><strong>Language:</strong> {person.language}</p>
          <p><strong>ID:</strong> {person.id}</p>
          <p>{person.bio}</p>
          <hr />
        </div>
      ))}
    </div>
  );
}

export default App;
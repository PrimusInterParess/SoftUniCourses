import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import { useState, useEffect } from 'react';
import { TodoList } from './components/TodoList';
import { Add } from './components/Add';

import { TodoContext } from './contexts/TodoContext';

const baseUrl = 'http://localhost:3030/jsonstore/todos'
function App() {
  const [todos, setTodos] = useState([]);

  const onChangeState = (todoId) => {
    console.log(todoId);

    todos.map(td => {
      if (td._id == todoId) {
        td.isCompleted = !td.isCompleted
      }
    })
    setTodos([...todos]);
  };

  useEffect(() => {
    fetch(baseUrl)
      .then(res => res.json())
      .then(result => {
        setTodos(Object.values(result))
      });
  }, []);

  return (
    <TodoContext.Provider value={'pesho'}>
      <div className="App">

        <TodoList todos={todos} onChangeState={onChangeState} />
        <Add />
        <button>Add</button>
      </div>
    </TodoContext.Provider>

  );
}

export default App;

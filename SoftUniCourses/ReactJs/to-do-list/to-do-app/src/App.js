import Footer from "./components/Footer";
import Header from "./components/Header";
import ToDoList from "./components/ToDoList";
import Loading from "./components/Loading";
import { useEffect, useState } from 'react';

function App() {

  const [todos, setTodos] = useState([]);
  const [isLoading,setIsloading] =useState(true);
  
  useEffect(() => {
    fetch('http://localhost:3030/jsonstore/todos')
      .then(res => res.json())
      .then(data => {
        setTodos(Object.values(data));
        setIsloading(false);
      })
  }, [])


  const toggleTodoStatus = (id) => {
    setTodos(state => state.map(t => t._id === id ? { ...t, isCompleted: !t.isCompleted } : t))
  }

  const onToDoAdd = () => {
    const lastId = todos[todos.length - 1]._id;
    const title = prompt('Task name:');
    const newTask = {
      id: lastId + 1,
      text:title,
      isCompleted:false,
    }
    setTodos(state => [newTask,...state]);
    
  }

  return (
    <div>

      <Header />
      <main className="main">
       {isLoading ? <Loading /> : <ToDoList data={todos} toggleTodoStatus={toggleTodoStatus} onToDoAdd={onToDoAdd} />}

      </main>

      <Footer />
    </div>
  );
}

export default App;

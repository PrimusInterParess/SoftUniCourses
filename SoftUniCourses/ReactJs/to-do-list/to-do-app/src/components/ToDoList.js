import AddButtonToDo from "./buttons/AddButtonToDo";

import Table from "./table/Table";


export default function ToDoList({
  data,
  toggleTodoStatus,
  onToDoAdd,
}) {
  return (
    <section className="todo-list-container">
      <h1>Todo List</h1>

      <AddButtonToDo onToDoAdd={onToDoAdd} />
      <div className="table-wrapper">
       
        <Table todos={data} toggleTodoStatus={toggleTodoStatus}   />
      </div>
    </section>
  );
};
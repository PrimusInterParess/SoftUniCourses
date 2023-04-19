import { useEffect, useState } from "react";
import { useContext } from "react";

import { TodoContext } from "../contexts/TodoContext";

export const TableRow = ({
  todo,
  onChangeState
}) => {
  const [curr, setCurr] = useState(todo);

  const context = useContext(TodoContext);

  return (
    <tr>
      <td>{todo.text}</td>
      <td>{todo.isCompleted ? 'Completed' : 'In proggress'}</td>
      <td><button onClick={() => onChangeState(todo._id)}>Change state</button></td>
    </tr>
  );
};
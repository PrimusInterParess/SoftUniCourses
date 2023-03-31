import { useState } from "react";

export default function TRow({ 
    todo,
    toggleTodoStatus
}) {
    const classes=['todo']
    return (
        <tr className={`todo ${todo.isCompleted?`is-completed`:''}`.trimEnd()}>
            <td>{todo.text}</td>
            <td>{todo.isCompleted ? `Complete` : 'Incomplete'}</td>
            <td className="todo-action">
                <button className="btn todo-btn" onClick={()=>toggleTodoStatus(todo._id)}>Change status</button>
            </td>
        </tr>);
};
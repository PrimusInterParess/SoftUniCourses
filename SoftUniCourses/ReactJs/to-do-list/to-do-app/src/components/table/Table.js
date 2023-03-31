import THead from "./THead";
import TRow from "./TRow";

export default function Table({
    todos,
    toggleTodoStatus,
}) {
    return (
        <table className="table">
            <THead />
            <tbody>
                {todos.map(t=>  <TRow key={t._id} todo={t} toggleTodoStatus={toggleTodoStatus} />)}
            </tbody>
        </table>);
};
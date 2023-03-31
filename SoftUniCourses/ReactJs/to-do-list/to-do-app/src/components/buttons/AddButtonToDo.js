export default function AddButtonToDo({onToDoAdd}){
    return(
        <div className="add-btn-container">
        <button className="btn" onClick={onToDoAdd}>+ Add new Todo</button>
      </div>
    );
}
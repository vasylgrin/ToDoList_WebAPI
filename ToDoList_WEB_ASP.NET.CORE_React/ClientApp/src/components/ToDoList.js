import React, { useEffect, useState } from "react"

const ToDoList = () => {

    const [toDoCollection, setToDoCollection] = useState([])

    useEffect(() => {
        fetch("api/todo/get")
            .then(response => { return response.json() })
            .then(responseJson => {
                setToDoCollection(responseJson)
            })
    }, [])

    const toDoList = toDoCollection.map(todo => <div>{todo.topic}</div>) 

    return (
        <div>
            {toDoList}
        </div>
    )

}

export default ToDoList;
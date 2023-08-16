import Swagger from "./components/Swagger";
import ToDoList from "./components/ToDoList";

const AppRoutes = [
    {
        path: '/get-todo',
        element: <ToDoList />
    },
    {
        path: '/swagger',
        element: <Swagger />
    },
];

export default AppRoutes;

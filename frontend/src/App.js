import React, {useState} from "react";
import TaskList from "./components/TaskList";
import CreateTaskForm from "./components/CreateTaskForm";

function App() {
  const [refreshFlag, setRefreshFlag] = useState(false);

  return (
    <div style ={{ padding: "20px" }}>
      <h1>Task Management App</h1>
      <CreateTaskForm onTaskCreated={() => setRefreshFlag(!refreshFlag)} />
      <TaskList key={refreshFlag} />
    </div>
  );
}

export default App;
      
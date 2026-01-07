import React, {useEffect, useState} from "react";
import { getTasks, updateTaskStatus, deleteTask } from "../services/api";

export default function TaskList() {
  const [tasks, setTasks] = useState([]);

  const fetchTasks = async () => {
    const data = await getTasks();
    setTasks(data);
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  const handleStatusChange = async (task, e) => {
    try {
    const newStatus = e.target.value;
    console.log("Updating task status:", task.id, newStatus);
    await updateTaskStatus(task.id, newStatus);
    fetchTasks();
    } catch (error) {
      console.error("Failed to update task status:", error);
    }
  };

    const handleDelete = async (taskId) => {
      await deleteTask(taskId);
      fetchTasks();
    };

    return (
        <div>
            <h2>Task List</h2>
            <table>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Status</th>
                        <th>Due Date</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {tasks.map(task => (
                        <tr key={task.id}>
                            <td>{task.title}</td>
                            <td>{task.description}</td>
                            <td>
                                <select
                                    value={task.status}
                                    onChange={(e) => handleStatusChange(task, e)}
                                >
                                    <option value="Pending">Pending</option>
                                    <option value="InProgress">In Progress</option>
                                    <option value="Completed">Completed</option>
                                </select>
                            </td>
                            <td>{new Date(task.dueDate).toLocaleDateString()}</td>
                            <td>
                                <button onClick={() => handleDelete(task.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
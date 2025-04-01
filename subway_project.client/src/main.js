import './assets/main.css'

import { createApp } from 'vue'
// import App from './App.vue'

// createApp(App).mount('#app')
let id = 0;
createApp({
    data() {
      return {
        todoId: 1,
        todoData: null,
        Counting: 0,
        newTodo: "",
        hideCompleted: false,
        todos: [
          { id: id++, text: "Learn HTML", done: false },
          { id: id++, text: "Learn JavaScript", done: false },
          { id: id++, text: "Learn Vue", done: false },
        ],
        menuItems: [
          {
            title: "Subs",
            submenu: ["Bröd", "Protein", "Ost", "Grönsaker", "Dressing"],
            open: false,
          },
          // {
          //   title: "Meny 2",
          //   submenu: ["Underpunkt A", "Underpunkt B"],
          //   open: false,
          // },
        ],
      };
    },
    computed: {
      filteredTodos() {
        return this.hideCompleted
          ? this.todos.filter((t) => !t.done)
          : this.todos;
      },
    },
    methods: {
      async fetchData() {
        this.todoData = null;
        const res = await fetch(
          `https://jsonplaceholder.typicode.com/todos/${this.todoId}`
        );
        this.todoData = await res.json();
      },
      addTodo() {
        this.todos.push({ id: id++, text: this.newTodo });
        this.newTodo = "";
      },
      removeTodo(todo) {
        this.todos = this.todos.filter((t) => t !== todo);
      },
      toggleDropdown(index) {
        this.menuItems[index].open = !this.menuItems[index].open;
      },
    },
    mounted() {
      this.fetchData();
    },
    watch: {
      todoId() {
        this.fetchData();
      },
    },
  }).mount("#app");

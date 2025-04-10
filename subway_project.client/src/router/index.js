import {createRouter, createWebHistory} from 'vue-router'
import StartPage from '@/views/StartPage.vue'
import OrderPage from '@/views/OrderPage.vue'

const routes = [
  {path: '/', name: 'StartPage', component: StartPage},
  {path: '/order', name: 'OrderPage', component: OrderPage},
];

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {path: '/', name: 'StartPage', component: StartPage},
  {path: '/order', name: 'OrderPage', component: OrderPage},
  ]
});

export default router;

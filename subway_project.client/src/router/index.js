import {createRouter, createWebHistory} from 'vue-router'
import StartPage from '@/views/StartPage.vue'
import OrderPage from '@/views/OrderPage.vue'
import KitchenPageVue from '@/views/KitchenViewPage.vue';
import CustomerOrderListPageVue from '@/views/CustomerOrderViewPage.vue';
import OrderConfirmation from '@/views/OrderConfirmation.vue';

const routes = [
  { path: '/', name: 'StartPage', component: StartPage },
  { path: '/order', name: 'OrderPage', component: OrderPage },
  { path: '/kitchen', name: 'KitchenViewPage', component: KitchenPageVue },
  { path: '/customer', name: 'CustomerOrderViewPage', component: CustomerOrderListPageVue },
  { path: '/orderconfirmation', name: 'OrderConfirmation', component: OrderConfirmation }
];

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', name: 'StartPage', component: StartPage },
    { path: '/order', name: 'OrderPage', component: OrderPage },
    { path: '/kitchen', name: 'KitchenPageView', component: KitchenPageVue },
    { path: '/customer', name: 'CustomerOrderViewPage', component: CustomerOrderListPageVue },
    { path: '/orderconfirmation', name: 'OrderConfirmation', component: OrderConfirmation }
  ]
});

export default router;

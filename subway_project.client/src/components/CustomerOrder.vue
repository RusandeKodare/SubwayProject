<script setup>
  import { defineProps } from 'vue';
  const props = defineProps({
    orders: Array,
    title: String,
    show: Boolean
  });

</script>

<template>
    <h2>{{ props.title }}</h2>
    <ul class="order-list" v-if="props.show">
        <li v-for="order in props.orders" :key="order.id">
            <div class="order-div">
                {{ order.id }}
            </div>
        </li>
    </ul>
</template>

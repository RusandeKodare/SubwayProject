import { defineStore } from 'pinia'

export const useOrderStore = defineStore('order', {
  state: () => ({
    order: {
        takeAway: false,
        totalPrice: 0,
        products: []
    }
  }),

  actions: {
    addProduct(product){
        this.order.products.push(product);
        console.log('PINIA: added product', product, 'to order:', this.order.products)
    },
    changeTakeAway(boolean){
        this.order.takeAway = boolean;
        console.log('PINIA: changed take away to:', boolean)
    },
    addToTotalPrice(price){
        this.order.totalPrice += price;
        console.log('PINIA: price added: ', price, 'new total: ', this.order.totalPrice)
    },
    removeProduct(product){
        const index = this.order.products.findIndex(p => p.id === product.id);
        if (index !== -1) {
            this.order.products.splice(index, 1);
            console.log('PINIA: removed product', product, 'from order:', this.order.products)
        } else {
            console.log('PINIA: product not found in order:', product)
        }
    },
    resetOrder(){
        this.order = {
            takeAway: false,
            totalPrice: 0,
            products: []
        }
        console.log('PINIA: order has been reset')
    }
  }
})

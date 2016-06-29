<template>
  <div id="app">
    <h2>Interest calculator</h2>
    <fieldset>
      <form id="form" v-on:submit.prevent="calc">
        <label>Init balance:</label>
        <input v-model="input.balance" type="number" min="0" max="999999999999" placeholder="init balance">
        <label>Interest rate:</label>
        <input v-model="input.rate" type="number" step="any" placeholder="rate">
        <label>Years:</label>
        <input v-model="input.years" type="number" min="0" max="9999" placeholder="years">
        <input type="submit" value="Calculate">
      </form>
    </fieldset>
    <div id="result" v-show="result">
      <h3>Final number: {{ result }}</h3>
    </div>
    <ul>
      <li v-show="errorMsg">{{ errorMsg }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      errorMsg: null,
      input: {
        balance: 10000,
        rate: 0.05,
        years: 5,
      },
      result: null,
    }
  },
  methods: {
    calc() {
      this.$http.get('/api/calc', { params: this.input }).then((response) => {
        this.errorMsg = null
        this.result = parseFloat(response.text()).toFixed(2)
      }, (response) => {
        // error callback
        this.result = null
        this.errorMsg = response.status + ': ' + response.text()
      });
    }
  }
}
</script>
